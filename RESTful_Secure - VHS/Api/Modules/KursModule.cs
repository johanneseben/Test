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
    public class KursModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public KursModule(KursService kursService)
            : base("/kurse")
        {
            Get["/"] = p =>
            {
                var kurse= kursService.Get();
                return new JsonResponse(kurse, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var kurs = kursService.Get(p.id);
                if(kurs == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(kurs, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Kurs post = this.Bind();
                try
                {
                    var result = kursService.Add(post);
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
                Kurs put = this.Bind();
                try
                {
                    var result = kursService.Update(put);
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
                    var result = kursService.Delete(p.id);
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
