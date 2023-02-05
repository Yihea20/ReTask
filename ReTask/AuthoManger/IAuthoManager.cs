using ReTask.Models.ViewModel;

namespace ReTask.AuthoManger
{
    public interface IAuthoManager
    {
        Task<bool> ValidateUser(LoginUserDTO UserDTO);
    }
}
