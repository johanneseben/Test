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
    public class SchluesselKontaktModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public SchluesselKontaktModule(SchluesselKontaktService schluesselKontaktService)
            : base("/schluesselKontakte")
        {
            Get["/"] = p =>
            {
                var schluesselKontakte= schluesselKontaktService.Get();
                return new JsonResponse(schluesselKontakte, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var schluesselKontakt = schluesselKontaktService.Get(p.id);
                if(schluesselKontakt == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(schluesselKontakt, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                SchluesselKontakt post = this.Bind();
                try
                {
                    var result = schluesselKontaktService.Add(post);
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
                SchluesselKontakt put = this.Bind();
                try
                {
                    var result = schluesselKontaktService.Update(put);
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
                    var result = schluesselKontaktService.Delete(p.id);
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
