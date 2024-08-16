using AutoMapper;
using Ibrahim.DoctorPortfolio.Dtos.About;
using Ibrahim.DoctorPortfolio.Dtos.BeforeAfter.Image;
using Ibrahim.DoctorPortfolio.Dtos.BeforeAfter.Video;
using Ibrahim.DoctorPortfolio.Dtos.Blog;
using Ibrahim.DoctorPortfolio.Dtos.Category;
using Ibrahim.DoctorPortfolio.Dtos.FAQ.Text;
using Ibrahim.DoctorPortfolio.Dtos.FAQ.Video;
using Ibrahim.DoctorPortfolio.Dtos.Review.Text;
using Ibrahim.DoctorPortfolio.Dtos.Review.Video;
using Ibrahim.DoctorPortfolio.Dtos.Video;
using Ibrahim.DoctorPortfolio.Entities;
using Ibrahim.DoctorPortfolio.Helpers;

namespace Ibrahim.DoctorPortfolio.Mappings
{
    public class GlobalMappingProfile: Profile 
    {
        public GlobalMappingProfile()
        {
            // procedure
            CreateMap<Procedure, ProcedureDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.NameAr, src.NameEn)));

            CreateMap<Procedure, ProcedureBriefDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.NameAr, src.NameEn)));

            CreateMap<Section, SectionDto>()
                .ForMember(dest => dest.Header, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.HeaderAr, src.HeaderEn)))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.BodyAr, src.BodyEn)));

            CreateMap<CreateOrUpdateProcedureDto, Procedure>();
            CreateMap<CreateSectionDto, Section>();

            // before after
            CreateMap<BeforeAfterImage, BeforeAfterImageDto>();
            CreateMap<CreateBeforeAfterImageDto, BeforeAfterImage>();
            CreateMap<BeforeAfterVideo, BeforeAfterVideoDto>();
            CreateMap<CreateBeforeAfterVideoDto, BeforeAfterVideo>();

            // reviews
            CreateMap<ReviewText, ReviewTextDto>()
                .ForMember(dest=>dest.ReviewerName, opt=>opt.MapFrom(src=> LocalizationHelpers.Localize(src.ReviewerNameAr, src.ReviewerNameEn)))
                .ForMember(dest=>dest.Review, opt=>opt.MapFrom(src=> LocalizationHelpers.Localize(src.ReviewAr, src.ReviewEn)))
                .ForMember(dest=>dest.SubReview, opt=>opt.MapFrom(src=> LocalizationHelpers.Localize(src.SubReviewAr, src.SubReviewEn)));

            CreateMap<CreateOrUpdateReviewTextDto, ReviewText>();
            CreateMap<ReviewVideo, ReviewVideoDto>();
            CreateMap<CreateReviewVideoDto, ReviewVideo>();

            // FAQ
            CreateMap<FAQText, FAQTextDto>()
                .ForMember(dest => dest.Question, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.QuestionAr, src.QuestionEn)))
                .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.AnswerAr, src.AnswerEn)));
            
            CreateMap<CreateOrUpdateFAQTextDto, FAQText>();
            CreateMap<FAQVideo, FAQVideoDto>();
            CreateMap<CreateFAQVideoDto, FAQVideo>();

            // videos
            CreateMap<Video, VideoDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.TitleAr, src.TitleEn)))
                .ForMember(dest => dest.SubTitle, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.SubTitleAr, src.SubTitleEn)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.DescriptionAr, src.DescriptionEn)));
            
            CreateMap<CreateOrUpdateVideoDto, Video>();

            // blog
            CreateMap<Blog, BlogDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.TitleAr, src.TitleEn)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.DescriptionAr, src.DescriptionEn)))
                .ForMember(dest => dest.WriterName, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.WriterNameAr, src.WriterNameEn)))
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.ContentAr, src.ContentEn)));
            
            CreateMap<Blog, BlogBriefDto>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.TitleAr, src.TitleEn)))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.DescriptionAr, src.DescriptionEn)))
                .ForMember(dest => dest.WriterName, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.WriterNameAr, src.WriterNameEn))); ;
            
            CreateMap<CreateOrUpdateBlogDto, Blog>();

            // about
            CreateMap<About, AboutDto>();

            CreateMap<FirstSection, FirstSectionDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.NameAr, src.NameEn)))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.TitleAr, src.TitleEn)))
                .ForMember(dest => dest.Quote, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.QuoteAr, src.QuoteEn)))
                .ForMember(dest => dest.Bio, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.BioAr, src.BioEn)));

            CreateMap<SecondSection, SecondSectionDto>()
                .ForMember(dest => dest.Header, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.HeaderAr, src.HeaderEn)))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.BodyAr, src.BodyEn)));
            
            CreateMap<ThirdSection, ThirdSectionDto>()
                .ForMember(dest => dest.Header, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.HeaderAr, src.HeaderEn)))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.BodyAr, src.BodyEn)));
            
            CreateMap<FourthSection, FourthSectionDto>()
                .ForMember(dest => dest.Header, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.HeaderAr, src.HeaderEn)))
                .ForMember(dest => dest.Body, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.BodyAr, src.BodyEn)));

            // shared
            CreateMap<Shared, SharedDto>();
            CreateMap<SocialLinks, SocialLinksDto>();

            CreateMap<ContactInfo, ContactInfoDto>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => LocalizationHelpers.Localize(src.AddressAr, src.AddressEn)));
        }
    }
}
