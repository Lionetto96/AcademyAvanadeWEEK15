using Microsoft.AspNetCore.Mvc;
using System;

namespace Avanade.Amazon.Api.Tests.Utils
{
    /// <summary>
    /// Utilities for parsing HTTP responses
    /// </summary>
    public static class ParseUtils
    {
        /// <summary>
        /// Checks if provided action result is 200-OK
        /// and converts the body to provided type of data
        /// </summary>
        /// <typeparam name="TOutputData">Type of data</typeparam>
        /// <param name="result">Input result</param>
        /// <returns>Returns parsed data</returns>
        public static TOutputData ExpectedOk<TOutputData>(IActionResult result)
            where TOutputData : class
        {
            //Validazione argomenti
            if (result == null) throw new ArgumentNullException(nameof(result));

            //Tento il casting a OkObjectResult (cast "morbido")
            OkObjectResult okResult = result as OkObjectResult;

            //Se il cast non va a buon fine, sollevo un'eccezione custom
            //che spiega all'utente qual'è il problema che si è verificato
            if (okResult == null)
                throw new InvalidProgramException($"Provided result should be of type '{typeof(OkObjectResult).Name}' but " +
                    $"is of type {result.GetType().Name}.");

            //Se arrivo qui sono sicuro cher è un 200-OK; quindi
            //estraggo le informazioni dal body e le converto in modo "morbido"
            //nel tipo di dato richiesto nell'invocazione della funzione
            TOutputData outputData = okResult.Value as TOutputData;

            //Se è nullo eccezione perchè il cast non è andato a buon fine
            if (outputData == null)
                throw new InvalidProgramException($"Provided body should be of type '{typeof(TOutputData).Name}'.");

            //Se va tutto bene, ritorno il dato
            return outputData;
        }
    }
}