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
			CreateMap<JobDto, Job>();
			CreateMap<Job, JobUpdateDto>();
			CreateMap<JobUpdateDto, Job>();
			CreateMap<NewJobDto, Job>();
			CreateMap<Job, NewJobDto>();
			CreateMap<Job, JobDtoReturn>();
			CreateMap<Job, JobExpensesDto>();
			CreateMap<NewExpense, Expense>();
			CreateMap<Expense, ExpenseDto>();

		}
	}
}
