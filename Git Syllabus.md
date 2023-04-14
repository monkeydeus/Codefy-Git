# Git
## What is Git
### A Database
### A Version Control System
### A Collaboration Framework


## Git Setup
### Install
### Configure
- user name, email at minimum
```c
git config --global user.name "< user name>"
git config --global user.email "< user email>"
```
#### Alias

## Git Tooling
### Git/OS
#### CLI
##### posh-git
#### CMD

### Coding
#### VS Code
#### GitLens
#### Webstorm

### Gitting
#### Tower Git
#### GitHub Desktop
#### Git Kraken
#### SourceTree
#### Tortoise Git for Windows

### Comparing
#### Beyond Compare
#### VS Code
#### KDiff3
#### P4Merge
#### WinMerge

## Git Internals

### The Working Directory
### The Staging Area (Index)
### The Repository
#### The Database
#### Database Objects
##### Blobs
##### Trees
##### Commits
```c
$git cat-file < hash >
$cat < filename >
```

Different trees can reference the same objects:
![[Pasted image 20230414152321.png]]
![[Pasted image 20230414152240.png]]


### The Stash




## Using Git
### What is a commit?
### What is a branch?
### What is the HEAD?

### Creating a Repo
#### Init
#### Clone

### Adding content to the Repo
#### Add
#### Commit

### Viewing The Repo
#### show
#### diff
#### log

### Moving within the Repo
#### branch
#### checkout
#### switch
#### tag

### Modifying the Repo
#### Merge
#### Rebase

### Fixing the Repo
#### amend commit
#### Revert
#### Reset
#### Rebase
#### Reflog

### Sharing the Repo
#### push

## Git Best Practices
### Finding a Workflow
#### Gitflow
#### Monolithic/Trunk

### Being a good citizen
#### Commit size
#### Commit messages

### Squash into Dev, Merge into Main

# Further Learning
[Tower Git](http://www.git-tower.com/learn)
[Git SCM](https://www.git-scm.com/)
[Roger Dudler](http://rogerdudler.github.io/git-guide/)