using CoreApiProject.Server.DTORequest;
using CoreApiProject.Server.IDataService;
using CoreApiProject.Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreApiProject.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieCategory : ControllerBase
    {
        private readonly IData _data;
        public MovieCategory(IData data)
        {
            _data = data;
        }

        [HttpGet("getAllCategories")]
        public IActionResult GetAll()
        {
            // تحقق إذا كان المستخدم مشرفًا
            var isAdmin = IsUserAdmin(); // استبدل هذا بالتحقق الفعلي من الـ JWT أو الجلسة

            // استرجاع الفئات بناءً على الصلاحيات
            var categories = _data.GetAllCategories(isAdmin);

            return Ok(categories);
        }

        private bool IsUserAdmin()
        {
            // تحقق من الـ JWT أو الجلسة لتحديد إذا كان المستخدم مشرفًا
            var userRole = User.FindFirst("role")?.Value; // هذه الطريقة إذا كنت تستخدم الـ JWT

            return userRole != null && userRole.Equals("Admin", StringComparison.OrdinalIgnoreCase);
        }


        [HttpPost("addCategory")]
        public IActionResult Add([FromBody] MovieCategoryDTO dto)
        {
            _data.AddCategory(dto);
            return Ok("Category added successfully");
        }


        [HttpDelete("deleteCategory/{id}")]
        public IActionResult Delete(int id, [FromQuery] bool isAdmin = false)
        {
            _data.DeleteCategory(id, isAdmin);
            return Ok("Category deleted successfully");
        }



        [HttpPut("editCategory/{id}")]
        public IActionResult Edit(int id, [FromBody] MovieCategoryDTO dto)
        {
            _data.EditCategory(id, dto);
            return Ok("Category updated successfully");
        }











    }
}
