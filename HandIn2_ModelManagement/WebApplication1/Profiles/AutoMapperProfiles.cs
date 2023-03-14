using AutoMapper;
using ModelManagement.Data;
using ModelManagement.Models;

namespace ModelManagement.Profiles
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles()
		{
			CreateMap<Model, ModelDto>();
			CreateMap<ModelDto, Model>();

			CreateMap<Job, JobDto>();
			CreateMap<Expense, ExpenseDto>();

		}
	}
}
