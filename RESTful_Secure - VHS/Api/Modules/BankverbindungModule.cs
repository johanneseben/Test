using Common.Services;
using Nancy;
using Nancy.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy.ModelBinding;
using Common.Models;
using Nancy.Serialization.JsonNet;
using Nancy.Security;

namespace Api.Modules
{
    public class BankverbindungModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public BankverbindungModule(BankverbindungService bankverbindungService)
            : base("/bankverbindungen")
        {
            Get["/"] = p =>
            {
                var bankverbindungen= bankverbindungService.Get();
                return new JsonResponse(bankverbindungen, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var bankverbindung = bankverbindungService.Get(p.id);
                if(bankverbindung == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(bankverbindung, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Bankverbindung post = this.Bind();
                try
                {
                    var result = bankverbindungService.Add(post);
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.Created;
            };

            Put["/"] = p =>
            {
                Bankverbindung put = this.Bind();
                try
                {
                    var result = bankverbindungService.Update(put);
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
                return HttpStatusCode.OK;
            };

            Delete["/{id}"] = p =>
            {
                try
                {
                    var result = bankverbindungService.Delete(p.id);
                    return new JsonResponse(result, new DefaultJsonSerializer());
                }
                catch (Exception ex)
                {
                    log.errorLog(ex.Message);
                    return HttpStatusCode.BadRequest;
                }
            };
        }
    }
}
