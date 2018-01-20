## Prerequisites
* Visual Studio 2017 or 2015
    * make sure that you have the newest version of Microsoft ASP.NET
* npm (if not having bower - look below)
	* it can be downloaded from https://nodejs.org/en/
* bower (if not using the one provided by Visual Studio)
	* it can be installed using npm: `npm install -g bower`

## Running the application
* open the `Arbetsprov.sln` solution in Visual Studio 
* in `Web.config` file find `appSettings` and fill values of `SpotifyClientId` and `SpotifyClientSecret`
* choose Debug -> Start Debugging

## Troubleshooting

Normally it should be enough to perform the steps in the previous steps, but in case of problems:
	* compiling problems: restore nuget packages,
	* styling problems: open command line in the project's main directory (where `bower.json` is located) and run `bower install`
	* restart Visual Studio,
	* choose Debug -> Start Debugging
