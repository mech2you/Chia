#V0.8 Adam Wilczek https://www.youtube.com/channel/UCz1rZ8wncJfC5NB23Pg9U0A
# 
#K32->  //4TB 36 //5TB 45 //10TB 91 //12TB 110 // 14TB 128 //16TB 147 //18TB 165
#//18TB 4 K34 72 K33 

param(
[string]$FarmerKey="",
[string]$ContractKey="",
[int]$K34Anzahl = 4,# 18TB 4
[int]$K33Anzahl = 72,#18TB 72                    
[int]$K32Anzahl = 0,        
[int]$RamSpeicher = 6000,
[int]$Threads = 30,
[int]$buckets = 256,
[int]$buckets3 = 256,
[string]$TmpDir="G:\ChiaTMP\",
[string]$TmpDir2=$TmpDir,
[string]$FinalDir="H:\089_18TB_SG_PP_MM\",
[string]$ChiaPfad="$env:LOCALAPPDATA\Chia-Blockchain\app-*\resources\app.asar.unpacked\daemon\madmax\chia_plot_k34.exe",
[string]$ChiaPfad32="$env:LOCALAPPDATA\Chia-Blockchain\app-*\resources\app.asar.unpacked\daemon\madmax\chia_plot.exe"
)
#Start-Sleep -Seconds 6200
#Erstellen der Verzeichnisse TMP
if (![System.IO.Directory]::Exists($TmpDir))
{
    Write-Output "Erstellen vom Verzeichnis "$TmpDir
    mkdir $TmpDir
}
if (![System.IO.Directory]::Exists($TmpDir2))
{
    Write-Output "Erstellen vom Verzeichnis "$TmpDir2
    mkdir $TmpDir2
}
#Erstellen des Final Verzeichnis
if (![System.IO.Directory]::Exists($FinalDir))
{
    Write-Output "Erstellen vom Verzeichnis "$FinalDir
    mkdir $FinalDir
}  
#Staren vom Plot K34
$process = Start-Process -FilePath $ChiaPfad -ArgumentList "plotters madmax -k 34 -n $K34Anzahl -r $Threads -u $buckets -v $buckets3 -t $TmpDir -2 $TmpDir2 -d $FinalDir -f $FarmerKey -c $ContractKey -K 3" -Wait  #-PassThru -RedirectStandardOutput $logPath
#Staren vom Plot K33
$process = Start-Process -FilePath $ChiaPfad -ArgumentList "plotters madmax -k 33 -n $K33Anzahl -r $Threads -u $buckets -v $buckets3 -t $TmpDir -2 $TmpDir2 -d $FinalDir -f $FarmerKey -c $ContractKey -K 3" -Wait  #-PassThru -RedirectStandardOutput $logPath
#Staren vom Plot K32
$process = Start-Process -FilePath $ChiaPfad32 -ArgumentList "plotters madmax -k 32 -n $K32Anzahl -r $Threads -u $buckets -v $buckets3 -t $TmpDir -2 $TmpDir2 -d $FinalDir -f $FarmerKey -c $ContractKey -K 3" -Wait  #-PassThru -RedirectStandardOutput $logPath