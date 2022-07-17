# Configuration README

## Table of Contents
1. [General Information](#general-info)
2. [Settings JSON File](#settings-json)

<a name="general-info"></a>
## General Information

This file contains information on items in the Configuration Directory. It will list out how to use the individual files within the directory. Items will be add as files are added.

<a name="settings-json"></a>
## Settings JSON File

The `settings.json` file contains all of the settings that are loaded into the application when it launches. Settings can be changed manually with a text editor or within the application.

### API Key

The first item in the file that is accessed is the API key. To get your own API key, navigate to [News Data](https://www.newsdata.io/) and sign up. They provide a free package that (as of the creation of this document) allows for up to 200 API calls a day.

Once you have obtained your API key from News Data, insert it here:
```
"ApiKey": "YOUR_API_KEY_HERE",
```
The API key should be placed in between the double quotes `"`. For example:
```
"ApiKey": "k3khfn330f09dfh20haqoi30",
```

### Country

Next is the country array. In this section you can add up to five different country sources. The countries should be written in a two letter, comma separated format. The two letter format can be found [here](https://www.iso.org/obp/ui/#search). Example:
```
"Country": [
  "us",
  "ca"
],
```

### Language

The last setting is the language setting. Similar to the country section, you can add up to five different language codes to the language array in the file. An example of the two letter language codes can be found [here](https://www.sitepoint.com/iso-2-letter-language-codes/). Example:
```
"Language": [
  "en",
  "fr"
]
```

### Settings JSON File Example

```
{
  "ApiKey": "k3khfn330f09dfh20haqoi30",
  "Country": [
    "us",
    "ca"
  ],
  "Language": [
    "en",
    "fr"
  ]
}
```