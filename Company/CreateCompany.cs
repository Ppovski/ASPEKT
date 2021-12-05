namespace Application.Company
{
    public class CreateCompany
    {
        public Int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }

    public class CommandValidation : AbstractValidator<Command>
    {
        public CommandValidation()
        {
            RuleFor(x => CompanyId).NotEmpty();
            RuleFor(x => CompanyName)..NotEmpty().MaximumLength(255);

        }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;
        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(Command request,
         CancellationToken cancellationToken)
        {
            var Company = new Company
            {
                CompanyId = request.Id,
                CompanyName = request.CompanyName

            };


            _context.Company.Add(company);
            var success = await _context.SaveChangesAsync() > 0;
            if (success) return Unit.Value;

            throw new Exception("Problem saving company");
        }
    }
}

