using AutoMapper;

namespace QuestionnaireApi.Common
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Entities.Form, Models.Form>();
            CreateMap<Entities.Question, Models.Question>();
            CreateMap<Entities.QuestionInfo, Models.QuestionInfo>()
                .ForMember(model => model.TypeId, entity => entity.MapFrom(x => x.Type.Id))
                .ForMember(model => model.Type, entity => entity.MapFrom(x => x.Type.Name))
                .ForMember(model => model.SelectOptions, entity
                    => entity.MapFrom(x => x.SelectOptions.Split('|', System.StringSplitOptions.None).ToArray()));
        }
    }
}
