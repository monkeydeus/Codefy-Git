### Cmder
https://cmder.app
Can use mini if Git installed. Using Full will not put git in path for use by windows terminal, fyi
#### Far Manager
https://farmanager.com/download.php?l=en

Integrate into Cmder
Cmder --> Settings --> Startup --> Tasks: "Add/Refresh default tasks"
![[Pasted image 20230420115454.png]]
##### BONUS: TreeView
```sh
> far:config
# Panel.Tree.TurnOffCompletely = false
# F9, Left/Right, Tree Panel (F9, L/R, T|I|V
)
```

### Micro
https://github.com/zyedidia/micro

### Windows Terminal
#### Install Windows Terminal from Store
Default Terminal w/new build:
![[Pasted image 20230420084741.png]]
![[Pasted image 20230420084817.png]]

After "Get" from WIndows Store:
![[Pasted image 20230420085125.png]]

Settings:
![[Pasted image 20230420085200.png]]

#### Install Oh My Posh
	[Windows | Oh My Posh](https://ohmyposh.dev/docs/installation/windows)
	- Manual Install
		```ps
		Set-ExecutionPolicy Bypass -Scope Process -Force; Invoke-Expression ((New-Object System.Net.WebClient).DownloadString('https://ohmyposh.dev/install.ps1'))
		```
#### Install Fonts (Ligature Support, Powerline Glyphso)
	- FiraCode
	- JetBrains Mono
	- SourceCodePro
	```bash
	oh-my-posh font install
	```
	![[Pasted image 20230420085822.png]]
##### Can set per profile, or default
- Per profile:
	![[Pasted image 20230420090947.png]]
	![[Pasted image 20230420090928.png]]

- Default:
![[Pasted image 20230420090743.png]]
#### Change Your Prompt
[Change your prompt | Oh My Posh](https://ohmyposh.dev/docs/installation/prompt)
```sh
notepad $PROFILE
# If error thrown, run
New-Item -Path $PROFILE -Type File -Force
#then
notepad $PROFILE
```

Add "oh-my-posh init pwsh | Invoke-Expression" (Do not include quotes) to profile

Reload new (edited) profile:
```sh
> . $PROFILE
```

![[Pasted image 20230420091438.png]]

[Customize | Oh My Posh](https://ohmyposh.dev/docs/installation/customize)
```sh
## oh-my-posh init pwsh --config "$env:POSH_THEMES_PATH/jandedobbeleer.omp.json" | Invoke-Expression
## oh-my-posh init pwsh --config "$env:POSH_THEMES_PATH/multiverse-neon.omp.json" | Invoke-Expression
## oh-my-posh init pwsh --config "$env:POSH_THEMES_PATH/patriksvensson.omp.json" | Invoke-Expression

```

Themes: https://ohmyposh.dev/docs/themes
![[Pasted image 20230420092801.png]]


#### Terminal Icons:
![[Pasted image 20230420093155.png]]

```ps
Install-Module -Name Terminal-Icons -Repository PSGallery
# notepad $PROFILE
Import-Module -Name Terminal-Icons
```

![[Pasted image 20230420093548.png]]