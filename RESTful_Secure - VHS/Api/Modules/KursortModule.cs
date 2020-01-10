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
    public class KursortModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public KursortModule(KursortService kursortService)
            : base("/kursorte")
        {
            Get["/"] = p =>
            {
                var kursorte= kursortService.Get();
                return new JsonResponse(kursorte, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var kursort = kursortService.Get(p.id);
                if(kursort == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(kursort, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Kursort post = this.Bind();
                try
                {
                    var result = kursortService.Add(post);
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
                Kursort put = this.Bind();
                try
                {
                    var result = kursortService.Update(put);
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
                    var result = kursortService.Delete(p.id);
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
