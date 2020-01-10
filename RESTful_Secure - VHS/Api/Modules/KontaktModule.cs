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
    public class KontaktModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public KontaktModule(KontaktService kontaktService)
            : base("/kontakte")
        {
            Get["/"] = p =>
            {
                var kontakte= kontaktService.Get();
                return new JsonResponse(kontakte, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var kontakt = kontaktService.Get(p.id);
                if(kontakt == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(kontakt, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Kontakt post = this.Bind();
                try
                {
                    var result = kontaktService.Add(post);
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
                Kontakt put = this.Bind();
                try
                {
                    var result = kontaktService.Update(put);
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
                    var result = kontaktService.Delete(p.id);
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
