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
    public class GutscheinModule : NancyModule
    {
        ErrorLogFile log = Program.log;

        public GutscheinModule(GutscheinService gutscheinService)
            : base("/gutscheine")
        {
            Get["/"] = p =>
            {
                var gutscheine= gutscheinService.Get();
                return new JsonResponse(gutscheine, new JsonNetSerializer());
            };

            Get["/{id}"] = p =>
            {
                var gutschein = gutscheinService.Get(p.id);
                if(gutschein == null)
                {
                    return HttpStatusCode.NotFound;
                }
                return new JsonResponse(gutschein, new JsonNetSerializer());
            };

            

            Post["/"] = p =>
            {
                Gutschein post = this.Bind();
                try
                {
                    var result = gutscheinService.Add(post);
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
                Gutschein put = this.Bind();
                try
                {
                    var result = gutscheinService.Update(put);
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
                    var result = gutscheinService.Delete(p.id);
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
