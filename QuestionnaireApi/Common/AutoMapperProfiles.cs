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
            CreateMap<Entities.Answer, Models.Answer>().ReverseMap();
            CreateMap<Entities.AnswerInfo, Models.AnswerInfo>().ReverseMap();
            CreateMap<Entities.FormState, Models.FormState>()
                .ForMember(model => model.FormId, entity => entity.MapFrom(model => model.Form.Id))
                .ForMember(model => model.UserId, entity => entity.MapFrom(model => model.User.UserId))
                .ForMember(model => model.CurrentQuestionId, entity => entity.MapFrom(model => model.CurrentQuestion.Id))
                .ForMember(model => model.FormStateTypeId, entity => entity.MapFrom(model => model.FormStateType.Id))
                .ForMember(model => model.FormStateType, entity => entity.MapFrom(model => model.FormStateType.Name));
            CreateMap<Entities.User, Models.User>().ReverseMap();
            CreateMap<Entities.Country, Models.Country>().ReverseMap();
        }
    }
}
