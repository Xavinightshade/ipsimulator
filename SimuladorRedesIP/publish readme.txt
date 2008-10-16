2.3.1.1 Enable Samesite for the .NET Framework 3.5 SP1 bootstrapper package 
If the .NET Framework 3.5 SP1 bootstrapper package is selected in the Prerequisite dialog box for a Setup project or in ClickOnce publishing, and also the "Download prerequisites from the same location as my application" option is selected, the following build error is shown:  

The install location for prerequisites has not been set to 'component vendor's web site' and the file 'dotNetFx35setup.exe' in item 'Microsoft.Net.Framework.3.5.SP1' cannot be located on disk. 

To resolve this issue:

Update the Package Data 
Open the [Program Files]\Microsoft SDKs\Windows\v6.0A\Bootstrapper\Packages\DotNetFx35SP1 folder or %ProgramFiles(x86)%\Microsoft SDKs\Windows\v6.0A\Bootstrapper\Packages\DotNetFx35SP1 on x64 operating systems 
Edit the Product.xml file in Notepad. 
Paste the following into the <PackageFiles> element: 
<PackageFile Name="TOOLS\clwireg.exe" />
<PackageFile Name="TOOLS\clwireg_x64.exe" />
<PackageFile Name="TOOLS\clwireg_ia64.exe" />

Find the element for <PackageFile Name="dotNetFX30\XPSEPSC-x86-en-US.exe" and change the PublicKey value to: 3082010A0282010100A2DB0A8DCFC2C1499BCDAA3A34AD23596BDB6CBE2122B794C8EAAEBFC6D526C232118BBCDA5D2CFB36561E152BAE8F0DDD14A36E284C7F163F41AC8D40B146880DD98194AD9706D05744765CEAF1FC0EE27F74A333CB74E5EFE361A17E03B745FFD53E12D5B0CA5E0DD07BF2B7130DFC606A2885758CB7ADBC85E817B490BEF516B6625DED11DF3AEE215B8BAF8073C345E3958977609BE7AD77C1378D33142F13DB62C9AE1AA94F9867ADD420393071E08D6746E2C61CF40D5074412FE805246A216B49B092C4B239C742A56D5C184AAB8FD78E833E780A47D8A4B28423C3E2F27B66B14A74BD26414B9C6114604E30C882F3D00B707CEE554D77D2085576810203010001 
Find the element for <PackageFile Name="dotNetFX30\XPSEPSC-amd64-en-US.exe" and change the PublicKey value to the same as in step 4 above 
Save the product.xml file 
Download and Extract the Core Installation Files 
Navigate to the following URL: http://go.microsoft.com/fwlink?LinkID=118080 
Download the dotNetFx35.exe file to your local disk. 
Open a Command Prompt window and change to the directory to which you downloaded dotNetFx35.exe. 
At the command prompt, type: 
dotNetFx35.exe /x:. 
This will extract the Framework files to a folder named “WCU” in the current directory. 
Copy the contents of the WCU\dotNetFramework folder and paste them in the %Program Files%\Microsoft SDKs\Windows\v6.0A\Bootstrapper\Packages\DotNetFx35SP1 folder (%ProgramFiles(x86)%\Microsoft SDKs\Windows\v6.0A\Bootstrapper\Packages\DotNetFx35SP1 on x64 operating systems). Note: Do not copy the WCU\dotNetFramework folder itself. There should be 5 folders under the WCU folder, and each of these should now appear in the DotNetFx35SP1 folder. The folder structure should resemble the following:
o DotNetFx35SP1 (folder) 
dotNetFX20 (folder 
dotNetFX30 (folder) 
dotNetFX35 (folder) 
dotNetMSP (folder) 
TOOLS folder) 
en (or some other localized folder) 
dotNetFx35setup.exe (file) 

You may now delete the files and folders you downloaded and extracted in steps 2 and 4.  
