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
    public class KontaktKursModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public KontaktKursModule(KontaktKursService kontaktKursService)
            : base("/kontaktKurse")
        {
            Get["/"] = p =>
            {
                var kontaktKurse= kontaktKursService.Get();
                return new JsonResponse(kontaktKurse, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var kontaktKurs = kontaktKursService.Get(p.id);
                if(kontaktKurs == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(kontaktKurs, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                KontaktKurs post = this.Bind();
                try
                {
                    var result = kontaktKursService.Add(post);
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
                KontaktKurs put = this.Bind();
                try
                {
                    var result = kontaktKursService.Update(put);
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
                    var result = kontaktKursService.Delete(p.id);
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
