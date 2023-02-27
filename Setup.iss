; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define TargetDir "FMRookieScouter\bin\Release\"  

#define MyAppVersion "1.0"
#define MyAppPublisher "Jaywapp. Inc"
#define MyAppURL "https://github.com/jaywapp"

#define MyAppName "FMRookieScouter"
#define MyAppExeName "FMRookieScouter.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{101CC74C-D8BE-4C64-A3AB-D7675863B1EC}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:\Program Files (x86)\Jaywapp\{#MyAppName}
UsePreviousAppDir=no
DisableProgramGroupPage=yes                                       
; Uncomment the following line to run in non administrative install mode (install for current user only.)
;PrivilegesRequired=lowest
OutputBaseFilename=FMRookieScouter_setup
Compression=lzma
SolidCompression=yes
WizardStyle=modern

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "{#TargetDir}*.exe"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#TargetDir}*.dll"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#TargetDir}*.dll.config"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#TargetDir}*.config"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#TargetDir}\DB\*.xml"; DestDir: "{app}\DB"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#TargetDir}\Image\Logo\*.png"; DestDir: "{app}\Image\Logo"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "{#TargetDir}\Image\Picture\*.png"; DestDir: "{app}\Image\Picture"; Flags: ignoreversion recursesubdirs createallsubdirs

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent