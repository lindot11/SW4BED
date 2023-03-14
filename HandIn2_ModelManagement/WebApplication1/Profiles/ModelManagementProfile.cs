using AutoMapper;
using ModelManagement.Data;
using ModelManagement.Models;

namespace ModelManagement.Profiles
{
	public class ModelManagementProfile : Profile
	{
		public ModelManagementProfile()
		{
			CreateMap<Model, ModelDto>();
			CreateMap<Job, JobDto>();
			CreateMap<Expense, ExpenseDto>();

		}
	}
}
