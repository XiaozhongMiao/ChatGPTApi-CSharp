﻿using Microsoft.AspNetCore.Mvc;

namespace ChatGPTApi.Controllers.Base
{
    [Route("api/{user}/[controller]/[action]")]
    [ApiController]
    public class BaseController : Controller
    {
        
    }
}
