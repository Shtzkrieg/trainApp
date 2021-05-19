module htmlSamp

    open Falco
    open Falco.Markup

    let htmlHandler : HttpHandler =
        let doc =
            Elem.html [ Attr.lang "en" ] [
                Elem.head [] [
                    Elem.title [] [ Text.raw "Sample App" ]
                ]
                Elem.body [] [
                    Elem.main [] [
                        Elem.h1 [] [ Text.raw "Sample App" ]
                    ]
                ]
            ]

        doc
        |> Response.ofHtml