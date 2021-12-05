namespace Application.Country
{
    public class CreateCountry
    {
        public Int CountryId { get; set; }
        public string CountryName { get; set; }
    }

    public class CommandValidation : AbstractValidator<Command>
    {
        public CommandValidation()
        {
            RuleFor(x => CountryId).NotEmpty();
            RuleFor(x => CountryName)..NotEmpty().MaximumLength(255);

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
            var Country = new Country
            {
                CountryId = request.Id,
                CountryName = request.CountryName

            };


            _context.Country.Add(country);
            var success = await _context.SaveChangesAsync() > 0;
            if (success) return Unit.Value;

            throw new Exception("Problem saving country");
        }
    }
}

