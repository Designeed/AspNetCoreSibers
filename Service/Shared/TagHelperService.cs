using AspNetCoreSibers.Controllers;

namespace AspNetCoreSibers.Service.Shared
{
    public class TagHelperService
    {
        public string AspProjectController { get => nameof(ProjectController).RemoveController(); }
        public string AspProjectIndexAction { get => nameof(ProjectController.Index); }
        public string AspProjectEditAction { get => nameof(ProjectController.Edit); }
        public string AspProjectDeleteAction { get => nameof(ProjectController.Delete); }
        public string AspProjectCreateAction { get => nameof(ProjectController.Create); }
        public string AspProjectAssignEmployeeAction { get => nameof(ProjectController.AssignEmployee); }

        public string AspEmployeeController { get => nameof(EmployeeController).RemoveController(); }
        public string AspEmployeeIndexAction { get => nameof(EmployeeController.Index); }
        public string AspEmployeeEditAction { get => nameof(EmployeeController.Edit); }
        public string AspEmployeeDeleteAction { get => nameof(EmployeeController.Delete); }
        public string AspEmployeeCreateAction { get => nameof(EmployeeController.Create); }
    }
}
