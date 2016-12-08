
# EFTaskCanceled

**Make sure you run this as a console app (i.e) not in IIS.**

This quick sample simply launches a query and then immediately explicity cancels it.

Entity Framework logs the TaskCanceled exception.  I view this as undesirable (although perhaps unavoidable) because I explicitly canceled the task.  I don't want it to pollute my logs with error messages that aren't really errors.

A real world example might be an app that launches two queries at once (a fast path and slow path query) and awaits with a Task.WhenAny and then sets the cancelation token to cancel any remaining queries.

Is there any way to suppress the logging of TaskCanceledExceptions?
