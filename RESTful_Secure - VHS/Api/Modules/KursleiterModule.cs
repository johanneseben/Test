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
    public class KursleiterModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public KursleiterModule(KursleiterService kursleiterService)
            : base("/kursleiter")
        {
            Get["/"] = p =>
            {
                var kursleiter= kursleiterService.Get();
                return new JsonResponse(kursleiter, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var kursleiter = kursleiterService.Get(p.id);
                if(kursleiter == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(kursleiter, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Kursleiter post = this.Bind();
                try
                {
                    var result = kursleiterService.Add(post);
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
                Kursleiter put = this.Bind();
                try
                {
                    var result = kursleiterService.Update(put);
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
                    var result = kursleiterService.Delete(p.id);
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
