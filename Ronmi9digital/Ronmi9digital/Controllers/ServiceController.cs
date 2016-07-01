using Ronmi9digital.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Ronmi9digital.Controllers
{
    
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ServiceController : ApiController
    {
    
        [HttpPost]
        public HttpResponseMessage Post(Show input)
        {
            if (input == null)
            {
                return Request.CreateResponse<Error>(HttpStatusCode.BadRequest, new Error
                {
                    error = "Could not decode request: JSON parsing failed"
                });
            }
            try
            {
                return Request.CreateResponse<Output>(HttpStatusCode.OK, ShowsWithDrmAndAtleastOneEpisode(input));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse<Error>(HttpStatusCode.BadRequest, new Error
                {
                    error = "Could not decode request: " + ex.Message
                });
            }
        }

    
        private Output ShowsWithDrmAndAtleastOneEpisode(Show input)
        {
            var data = (from p in input.payload
                        where
                            p.drm &&
                            p.episodeCount > 0
                        select new Response
                        {
                            image = p.image.showImage,
                            slug = p.slug,
                            title = p.title
                        }
                        ).ToList();
            return new Output
            {
                response = data
            };
        }

    }

}