using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NoteBookAPI.Helper;
using NoteBookAPI.Models;
using NoteBookAPI.Services;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace NoteBookAPI.Controllers
{
    [ApiController]
    [Route("api/Log/")]
    public class QueryController : ControllerBase
    {
        private readonly IUserDetailRepositary _userDetailRepositary;
        private readonly IMapper _mapper;
        public static IWebHostEnvironment _environment;


        public QueryController(IUserDetailRepositary UserDetailRepositary, IMapper mapper, IWebHostEnvironment environment)
        {
            _userDetailRepositary = UserDetailRepositary ?? throw new ArgumentNullException(nameof(UserDetailRepositary));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _environment = environment;

        }
        [Authorize]
        [HttpHead]
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> Query([FromQuery] UserResourceParameter userResourceParameter)
        {
            var ResourceFromRepo = _userDetailRepositary.GetUsers(userResourceParameter);
           
            var PreviousPageLink = ResourceFromRepo.HasPrevious ?
                CreateBandUri(userResourceParameter, UriType.PreviousPage) : null;
            var NextPageLink = ResourceFromRepo.HasNext ?
                CreateBandUri(userResourceParameter, UriType.NextPage) : null;

            var metaData = new
            {
                totalCount = ResourceFromRepo.TotalCount,
                pageSize = ResourceFromRepo.PageSize,
                currentPage = ResourceFromRepo.CurrentPage,
                totalPage = ResourceFromRepo.TotalPages,
                previousPageLink = PreviousPageLink,
                nextPageLink = NextPageLink
            };

            Response.Headers.Add("Pagination", JsonSerializer.Serialize(metaData));

            var items=_mapper.Map<IEnumerable<UserDto>>(ResourceFromRepo);
            return Ok();

        }

        private string CreateBandUri(UserResourceParameter userResourceParameter, UriType uriType)
        {
            switch (uriType)
            {
                case UriType.PreviousPage:
                    return Url.Link("Query", new
                    {
                        PageNo = userResourceParameter.PageNo - 1,
                        pageSisze = userResourceParameter.PageSize,
                        FirstName = userResourceParameter.FirstName

                    });
                case UriType.NextPage:
                    return Url.Link("Query", new
                    {
                        PageNo = userResourceParameter.PageNo + 1,
                        pageSisze = userResourceParameter.PageSize,
                        FirstName = userResourceParameter.FirstName

                    });
                default:
                    return Url.Link("Query", new
                    {
                        PageNo = userResourceParameter.PageNo,
                        pageSisze = userResourceParameter.PageSize,
                        FirstName = userResourceParameter.FirstName

                    });
            }
        }

    }
}
