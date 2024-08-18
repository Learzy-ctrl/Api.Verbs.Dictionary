using Api.Verbs.Dictionary.Models;
using Api.Verbs.Dictionary.Persistence;
using CsvHelper.Configuration;
using CsvHelper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Api.Verbs.Dictionary.Aplication
{
    public class Query
    {
        public class QueryVerb : IRequest<VerbDto>
        {
            public string verb { get; set; }
            public string verbForm { get; set; }
        }

        public class handler : IRequestHandler<QueryVerb, VerbDto>
        {
            private readonly EnglishVerbsContext _context;

            public handler(EnglishVerbsContext context)
            {
                _context = context;
            }

            public async Task<VerbDto>Handle (QueryVerb request, CancellationToken cancellationToken)
            {
                var verbDto = new VerbDto();
                var verbForms = await _context.Verbs.Where(v => v.present == request.verb || v.spanish == request.verb || v.past == request.verb || v.pastParticiple == request.verb).FirstOrDefaultAsync();
                if (verbForms != null)
                {
                    switch (request.verbForm)
                    {
                        case "Simple":
                            verbDto.verb = verbForms.present;
                            break;
                        case "Past":
                            verbDto.verb = verbForms.past;
                            break;
                        case "Past participle":
                            verbDto.verb = verbForms.pastParticiple;
                            break;
                        case "Spanish":
                            verbDto.verb = verbForms.spanish;
                            break;
                        case "Pronunciation":
                            verbDto.verb = verbForms.pronuciation;
                            break;
                    }
                    return verbDto;
                }
                return null;
            }
        }
    }
}
