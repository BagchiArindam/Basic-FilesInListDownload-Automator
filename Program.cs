// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
distinctHrefs.forEach(function(href) {
    var anchor = document.createElement('a');
    anchor.setAttribute('href', href);
    anchor.setAttribute('download', href.substring(href.lastIndexOf('/') + 1).replace(".txt", ".py"));
    anchor.style.display = 'none';
    document.body.appendChild(anchor);

    fetch(href)
      .then(function(response) {
        if (!response.ok)
        {
            throw new Error('HTTP error, status = ' + response.status);
        }
        return response.blob();
    })
    .then(function(blob) {
        var url = URL.createObjectURL(blob);
        anchor.setAttribute('href', url);
        anchor.click();
    })
    .catch (function(error) {
        console.log('Error: ' + error.message);
    });
    });
