using AutoMapper;
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

namespace Ibrahim.DoctorPortfolio.Mappings
{
    public class GlobalMappingProfile: Profile 
    {
        public GlobalMappingProfile()
        {
            // category
            CreateMap<Procedure, ProcedureDto>();
            CreateMap<Procedure, ProcedureBriefDto>();
            CreateMap<Section, SectionDto>();
            CreateMap<CreateOrUpdateProcedureDto, Procedure>();
            CreateMap<CreateSectionDto, Section>();

            // before after
            CreateMap<BeforeAfterImage, BeforeAfterImageDto>();
            CreateMap<CreateBeforeAfterImageDto, BeforeAfterImage>();
            CreateMap<BeforeAfterVideo, BeforeAfterVideoDto>();
            CreateMap<CreateBeforeAfterVideoDto, BeforeAfterVideo>();

            // reviews
            CreateMap<ReviewText, ReviewTextDto>();
            CreateMap<CreateOrUpdateReviewTextDto, ReviewText>();
            CreateMap<ReviewVideo, ReviewVideoDto>();
            CreateMap<CreateReviewVideoDto, ReviewVideo>();

            // FAQ
            CreateMap<FAQText, FAQTextDto>();
            CreateMap<CreateOrUpdateFAQTextDto, FAQText>();
            CreateMap<FAQVideo, FAQVideoDto>();
            CreateMap<CreateFAQVideoDto, FAQVideo>();

            // videos
            CreateMap<Video, VideoDto>();
            CreateMap<CreateOrUpdateVideoDto, Video>();

            // blog
            CreateMap<Blog, BlogDto>();
            CreateMap<Blog, BlogBriefDto>();
            CreateMap<CreateOrUpdateBlogDto, Blog>();
        }
    }
}
