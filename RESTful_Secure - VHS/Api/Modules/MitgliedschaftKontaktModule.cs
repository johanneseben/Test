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
    public class MitgliedschaftKontaktModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public MitgliedschaftKontaktModule(MitgliedschaftKontaktService mitgliedschaftKontaktService)
            : base("/mitgliedschaftKontakte")
        {
            Get["/"] = p =>
            {
                var mitgliedschaftKontakte= mitgliedschaftKontaktService.Get();
                return new JsonResponse(mitgliedschaftKontakte, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var mitgliedschaftKontakt = mitgliedschaftKontaktService.Get(p.id);
                if(mitgliedschaftKontakt == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(mitgliedschaftKontakt, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                MitgliedschaftKontakt post = this.Bind();
                try
                {
                    var result = mitgliedschaftKontaktService.Add(post);
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
                MitgliedschaftKontakt put = this.Bind();
                try
                {
                    var result = mitgliedschaftKontaktService.Update(put);
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
                    var result = mitgliedschaftKontaktService.Delete(p.id);
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
