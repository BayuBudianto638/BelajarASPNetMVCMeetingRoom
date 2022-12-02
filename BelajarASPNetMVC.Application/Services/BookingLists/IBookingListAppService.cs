using BelajarASPNetMVC.Application.Models;
using BelajarASPNetMVC.Application.Services.BookingLists.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarASPNetMVC.Application.Services.BookingLists
{
    public interface IBookingListAppService
    {
        BookingDto GetById(int id);
        IEnumerable<BookingDto> GetAll(int pageIndex = 1, int pageSize = 10);
        //IEnumerable<BookingDetailListDto> GetBookingByBookCode(string bookCode);
        IEnumerable<BookingDto> GetSubmitted(int submit);
        //BookPayment GetBookingPayRoom(int id);
        void Create(BookingDto booking);
        void Update(BookingDto booking);
        void UpdateData(BookingDto booking);
        void Delete(int id);
        void IsDeleted(int id);

        void ConvertHTMLToPDF(string html, string fileName);
        void SendMailOR(string emailClient, string id, string messageBody, SmtpServer smtpServer, string attachmentString);
        string SendMailWOA(string emailClient, string id, string messageBody, SmtpServer smtpServer);
        void SendMailInvoice(string emailClient, string id, string messageBody, SmtpServer smtpServer);
    }
}
