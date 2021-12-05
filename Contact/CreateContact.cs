namespace Application.Contact
{
    public class CreateContact
    {
        public Int ContactId { get; set; }
        public string ContactName { get; set; }
        public int CompanyId { get; set; }
        public int Countryid {get; set;}
    }

    public class CommandValidation : AbstractValidator<Command>
    {
        public CommandValidation()
        {
            RuleFor(x => ContactId).NotEmpty();
            RuleFor(x => ContactName)..NotEmpty().MaximumLength(255);
            RuleFor(x => CompanyId).NotEmpty();
            RuleFor(x => Countryid)..NotEmpty().MaximumLength(255);

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
            var Contact = new Contact
            {
                ContactId = request.Id,
                ContactName = request.ContactName,
                CompanyId=request.CompanyId,
                Countryid= request.Countryid

            };


            _context.Contact.Add(contact);
            var success = await _context.SaveChangesAsync() > 0;
            if (success) return Unit.Value;

            throw new Exception("Problem saving Contact");
        }
    }
}

