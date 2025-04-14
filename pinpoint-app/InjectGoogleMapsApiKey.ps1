param(
    [string]$ManifestPath,
    [string]$ApiKey
)

[xml]$manifest = Get-Content $ManifestPath
$nsMgr = New-Object System.Xml.XmlNamespaceManager($manifest.NameTable)
$nsMgr.AddNamespace("android", "http://schemas.android.com/apk/res/android")

$node = $manifest.SelectSingleNode("//meta-data[@android:name='com.google.android.geo.API_KEY']", $nsMgr)
if ($node -ne $null) {
    $node.Attributes["android:value"].Value = $ApiKey
    $manifest.Save($ManifestPath)
    Write-Output "Injected API key into AndroidManifest.xml"
} else {
    Write-Error "Could not find the meta-data node to update"
}
