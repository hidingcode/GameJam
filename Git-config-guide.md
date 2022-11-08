# Git Config File Guide

1. Create a file named `.gitconfig` in your home directory. 

```yaml
[merge]
tool = unityyamlmerge

[mergetool "unityyamlmerge"]
trustExitCode = false
cmd = '<path to UnityYAMLMerge>' merge -p "$BASE" "$REMOTE" "$LOCAL" "$MERGED"
```

2. Replace `<path to UnityYAMLMerge>` with the path to the UnityYAMLMerge executable.
3. If you installed Unity on the default location, the path should be 

**Windows**
```powershell
C:\Program Files\Unity\Editor\Data\Tools\UnityYAMLMerge.exe

or

C:\Program Files (x86)\Unity\Editor\Data\Tools\UnityYAMLMerge.exe
```

**MacOS**
```zsh
/Applications/Unity/Unity.app/Contents/Tools/UnityYAMLMerge
```