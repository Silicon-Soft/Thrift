using CrudEmployee.ViewModel;

namespace CrudEmployee.Services
{
    public interface IEmployeeService
    {
        List<EmployeeViewModel> EmployeeViewModels();
        EmployeeViewModel Read(int id);
        void Create(EmployeeViewModel employeeViewData);
        void Edit(EmployeeViewModel employeeViewData);
        void ConfirmDelete(int id);
    }
      

}
