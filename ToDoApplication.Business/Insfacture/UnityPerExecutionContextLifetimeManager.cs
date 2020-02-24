using Microsoft.Practices.Unity;
using System;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Web;

namespace ToDoApplication.Business.Insfacture
{
    public class UnityPerExecutionContextLifetimeManager : LifetimeManager
    {
        #region Nested

        class ContainerExtension : IExtension<OperationContext>
        {
            #region Members

            public object Value { get; set; }

            #endregion

            #region IExtension<OperationContext> Members


            public void Attach(OperationContext owner)
            {

            }


            public void Detach(OperationContext owner)
            {

            }

            #endregion
        }
        #endregion

        #region Members

        Guid _key;

        #endregion

        #region Constructor

        public UnityPerExecutionContextLifetimeManager() : this(Guid.NewGuid()) { }


        UnityPerExecutionContextLifetimeManager(Guid key)
        {
            if (key == Guid.Empty)
                throw new ArgumentException("Key cannot be empty");

            _key = key;
        }
        #endregion

        #region ILifetimeManager Members

        public  override object GetValue()
        {
            object result = null;

            if (OperationContext.Current != null)
            {
                var containerExtension = OperationContext.Current.Extensions.Find<ContainerExtension>();
                if (containerExtension != null)
                {
                    result = containerExtension.Value;
                }
            }
            else if (HttpContext.Current != null)
            {

                if (HttpContext.Current.Items[_key.ToString()] != null)
                    result = HttpContext.Current.Items[_key.ToString()];
            }
            else
            {

                if (AppDomain.CurrentDomain.IsFullyTrusted)
                {
                    result = CallContext.GetData(_key.ToString());
                }
            }

            return result;
        }

        public override void RemoveValue()
        {
            if (OperationContext.Current != null)
            {

                var containerExtension = OperationContext.Current.Extensions.Find<ContainerExtension>();
                if (containerExtension != null)
                    OperationContext.Current.Extensions.Remove(containerExtension);

            }
            else if (HttpContext.Current != null)
            {

                if (HttpContext.Current.Items[_key.ToString()] != null)
                    HttpContext.Current.Items[_key.ToString()] = null;
            }
            else
            {
                CallContext.FreeNamedDataSlot(_key.ToString());
            }
        }

        public override void SetValue(object newValue)
        {

            if (OperationContext.Current != null)
            {

                var containerExtension = OperationContext.Current.Extensions.Find<ContainerExtension>();
                if (containerExtension == null)
                {
                    containerExtension = new ContainerExtension()
                    {
                        Value = newValue
                    };

                    OperationContext.Current.Extensions.Add(containerExtension);
                }
            }
            else if (HttpContext.Current != null)
            {

                if (HttpContext.Current.Items[_key.ToString()] == null)
                    HttpContext.Current.Items[_key.ToString()] = newValue;
            }
            else
            {

                if (AppDomain.CurrentDomain.IsFullyTrusted)
                {
                    CallContext.SetData(_key.ToString(), newValue);
                }
            }
        }

        #endregion
    }
}
