using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ReTask.IRepository;
using ReTask.Models;
using ReTask.Models.ViewModel;

namespace ReTask.Controllers
{
    public class NewssController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public NewssController(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult>GetAll()
        {
            var news = await _unitOfWork.News.GetAll();
           // var result = _mapper.Map<NewsDTO>(news);
            return View(news);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(NewsDTO newsDTO) {
            var news = _mapper.Map<News>(newsDTO);
            await _unitOfWork.News.Insert(news);
            await _unitOfWork.Save();
            return RedirectToAction("Add");
        }
        [HttpGet]
        public async Task<IActionResult>Get(int id)
        {
            var news = await _unitOfWork.News.Get(x=>x.Id==id);
            
            return View(news);  
        }
        
        [HttpPost]
        public async Task<IActionResult>Get(News newsDTO)
        {
            var old = await _unitOfWork.News.Get(q => q.Id ==newsDTO.Id);
            if (old != null)
            {
                _unitOfWork.News.Update(newsDTO);
                await _unitOfWork.Save();
                return RedirectToAction("GetAll");
            }else 
                return RedirectToAction("GetAll");
        }
        [HttpGet]
        public async Task<IActionResult>Delet(int id)
        {
            await _unitOfWork.News.Delete(id);
            await _unitOfWork.Save();
            return RedirectToAction("GetAll");
        }
    }
}
