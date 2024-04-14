namespace PracticeTracker.Services.Tools;

public class Response
{
    private List<Error> Errors { get; set; }

    public Boolean IsSuccess => Errors.Count == 0;
	public Boolean IsFailed => Errors.Count > 0;

	public dynamic Data { get; protected set; }

    public Response()
    {
        Errors = new List<Error>();
    }

    public Response(dynamic data)
    {
        Errors = new List<Error>();
        Data = data;
    }

    public Response(dynamic data, List<Error> errors)
    {
        Data = data;
        Errors = errors;
    }

    public Response SetData(dynamic data)
    {
        Data = data;

        return this;
    }

    public Response AddError(Error error)
    {
        Errors.Add(error);

        return this;
    }

    public Response AddError(IList<Error> errors)
    {
        Errors.AddRange(errors);

        return this;
    }


    public Response AddError(String message)
    {
        Errors.Add(new Error(message));

        return this;
    }

    public Response AddError(IList<String> messages)
    {
        Errors.AddRange(messages.Select(x => new Error(x)));

        return this;
    }

    public Response AddError(Exception exception)
    {
        Errors.Add(new Error(exception.Message));

        return this;
    }

    public Response AddError(String key, String message)
    {
        Errors.Add(new Error(key, message));

        return this;
    }

    public static Response Success(dynamic data = null)
    {
        Response result = new Response
        {
            Errors = new List<Error>(),
            Data = data
        };

        return result;
    }

    public static Response Failed(IList<Error> errors)
    {
        Response result = new Response
        {
            Errors = errors.ToList()
        };

        return result;
    }

    public static Response Failed(IList<String> errors)
    {
        Response result = new Response();

        result.Errors.AddRange(errors.Select(x => new Error(x)));

        return result;
    }

    public static Response Failed(IList<KeyValuePair<String, String>> errors)
    {
        return new Response().AddError(errors.Select(x => x.Value).ToArray());
    }

    public static Response Failed(String error)
    {
        Response result = new Response();

        result.Errors.Add(new Error(error));

        return result;
    }

    public static Response Failed(IEnumerable<Error> errors)
    {   
        Response result = new Response();
        
        result.Errors.AddRange(errors);

        return result;
    }
}