using System.Threading.Tasks;
using AutoMapper;
using BasicFramework.Appliction.ViewModels.User;
using BasicFramework.Dommain.Repositorys;

namespace BasicFramework.Appliction.Queries.Impl
{
    /// <summary>
    /// 用户模块查询器
    /// </summary>
    public class UserQueries : IUserQueries
    {
     
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userReadOnlyRepository"></param>
        public UserQueries(IUserReadOnlyRepository userReadOnlyRepository,IMapper mapper)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// 根据Id获取用户基础信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<UserResponseDto> GetUserById(string Id)
        {
           var model=await  _userReadOnlyRepository.GetByKeyAsync(Id);
           return _mapper.Map<UserResponseDto>(model);
        }
    }
}
