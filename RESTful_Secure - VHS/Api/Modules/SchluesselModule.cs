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
    public class SchluesselModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public SchluesselModule(SchluesselService schluesselService)
            : base("/schluessel")
        {
            Get["/"] = p =>
            {
                var schluessel= schluesselService.Get();
                return new JsonResponse(schluessel, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var schluessel = schluesselService.Get(p.id);
                if(schluessel == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(schluessel, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Schluessel post = this.Bind();
                try
                {
                    var result = schluesselService.Add(post);
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
                Schluessel put = this.Bind();
                try
                {
                    var result = schluesselService.Update(put);
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
                    var result = schluesselService.Delete(p.id);
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
