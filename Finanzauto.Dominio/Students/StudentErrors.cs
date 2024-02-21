using ErrorOr;

namespace Finanzauto.Dominio.Students
{
    public class StudentErrors
    {
        public static Error StudentIsRequired { get; } = Error.Validation(
            code: "Student.Required",
            description: "No se recibio la información del estudiante."
        );

        public static Error StudentNotFound { get; } = Error.NotFound(
            code: "Student.NotFound",
            description: "No se encontro el estudiante solicitado."
        );

        public static Error StudentWithoutId { get; } = Error.Validation(
            code: "Student.WithoutId",
            description: "No se recibio el id del estudiante."
        );

        public static Error StudentWithoutIdentification { get; } = Error.Validation(
            code: "Student.WithoutIdentification",
            description: "No se recibio la identificacion del estudiante."
        );

        public static Error StudentInvalid { get; } = Error.Validation(
            code: "Student.invalid",
            description: "No se recibieron todos los datos del estudiante."
        );

        public static Error StudentExist { get; } = Error.Validation(
            code: "Student.exist",
            description: "El estudiante con esa identificacion ya existe en la base de datos."
        );
    }
}
