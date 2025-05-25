using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esnafim_1.Application.Features.Mediator.Results.AppointmentResults
{
    public class GetAppointmentByIdQueryResult
    {
        public int AppointmentId { get; set; }
        public int UserId { get; set; } //Kullanıcı Tablosu ile Bağlantı
        public int BusinessId { get; set; } //İşletme Tablosu ile Bağlantı
        public int EmployeeId { get; set; } //Çalışan Tablosu ile bağlantı
        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }
        public string Note { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApprovedDate { get; set; }
        public bool CustomerArrive { get; set; }
    }
}
