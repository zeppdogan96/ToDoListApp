using System;
using System.ComponentModel.DataAnnotations;
using ToDoApplication.Core.Classes;

namespace ToDoApplication.Common.Classes
{
    public class TaskTemplate : FilterBaseTemplate
    {
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Lütfen İsim Yazınız.")]
        public string TaskName { get; set; }
        [Required(ErrorMessage = "Lütfen Açıklama Yazınız.")]
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Tarih Alanı Girilmesi Zorunludur.")]
        public DateTime Date { get; set; }
        public int StatuId { get; set; }
        public int LevelId { get; set; }
    }
}
