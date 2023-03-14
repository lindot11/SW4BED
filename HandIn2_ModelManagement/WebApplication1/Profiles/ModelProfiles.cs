using AutoMapper;
using ModelManagement.Data;
using ModelManagement.Models;

namespace ModelManagement.Profiles
{
	public class ModelProfiles : Profile
	{
		public ModelProfiles()
		{
			CreateMap<ModelDto, Model>();
			CreateMap<Model, ModelDto>();
		}
	}
}
