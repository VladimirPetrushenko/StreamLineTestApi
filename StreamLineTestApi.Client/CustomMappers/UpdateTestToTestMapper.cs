using AutoMapper;
using StreamLineTestApi.Client.Models.Dto.Answer;
using StreamLineTestApi.Client.Models.Dto.Question;
using StreamLineTestApi.Client.Models.Dto.Test;
using StreamLineTestApi.Client.Models.Interfaces;
using StreamLineTestApi.Data.Repository;
using StreamLineTestApi.Domain.Models;

namespace StreamLineTestApi.Client.CustomMappers
{
    public class UpdateTestToTestMapper
    {
        private readonly TestUpdateDto _testUpdate;
        private readonly Test _test;
        private readonly IMapper _mapper;
        private readonly IRepository<QuestionsAnswer> _questionsAnswerRepository;
        private readonly IRepository<TestsQuestion> _testsQuestionRepository;

        public UpdateTestToTestMapper(
            Test test, 
            TestUpdateDto testUpdate, 
            IMapper mapper, 
            IRepository<QuestionsAnswer> questionsAnswerRepository, 
            IRepository<TestsQuestion> testsQuestionRepository)
        {
            _testUpdate = testUpdate;
            _test = test;
            _mapper = mapper;
            _questionsAnswerRepository = questionsAnswerRepository;
            _testsQuestionRepository = testsQuestionRepository;
        }

        public async Task<bool> MapAsync()
        {
            try
            {
                _mapper.Map(_testUpdate, _test);
                await MapOrCreateQuestionsAsync(_testUpdate.Questions);

                return true;
            }
            catch
            {
                return false;
            }
        }

        private async Task MapOrCreateQuestionsAsync(List<QuestionUpdateDto> questionUpdateDtos)
        {
            foreach (var questionUpdate in questionUpdateDtos)
            {
                if (await IsExistEntityAsync(_testsQuestionRepository, questionUpdate))
                {
                    await MapAsync(_testsQuestionRepository, questionUpdate);
                }
                else
                {
                    await CreateAsync(_testsQuestionRepository, questionUpdate);
                }

                await MapOrCreateAnswersAsync(questionUpdate.Answers);
            }
        }

        private async Task MapOrCreateAnswersAsync(List<AnswerUpdateDto> answerUpdateDtos)
        {
            foreach (var answerUpdate in answerUpdateDtos)
            {
                if (await IsExistEntityAsync(_questionsAnswerRepository, answerUpdate))
                {
                    await MapAsync(_questionsAnswerRepository, answerUpdate);
                }
                else
                {
                    await CreateAsync(_questionsAnswerRepository, answerUpdate);
                }
            }
        }

        private static async Task<bool> IsExistEntityAsync<T, Y>(IRepository<T> repository, Y update)
            where Y : class, IId
        {
            var item = await repository.GetByID(update.Id);
            return item != null;
        }

        private async Task MapAsync<T, Y>(IRepository<T> repository, Y update)
            where Y : class, IId
        {
            var item = await repository.GetByID(update.Id);
            _mapper.Map(update, item);
        }

        private async Task CreateAsync<T, Y>(IRepository<T> repository, Y update)
        {
            var model = _mapper.Map<T>(update);
            await repository.CreateItem(model);
            await repository.SaveChanges();
        }
    }
}
