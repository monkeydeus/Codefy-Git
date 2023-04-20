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
A commit is a snapshot of the current state of a Git repository. It includes a set of changes to the repository's files that you've made since the last commit, along with a commit message describing the changes. Commits allow you to keep track of changes to your code over time
### What is a branch?
A branch is a separate line of development in a Git repository. It's essentially a copy of the codebase at a certain point in time, and you can make changes to it without affecting the main codebase. This allows you to experiment with new features or make changes without worrying about breaking the existing code. Braches are made up of commits, and you can see the entire history of a single branch by checking its commit history
### What is the HEAD?
The HEAD is a reference to the current commit in a branch. It's essentially a pointer that tells Git which commit you're currently working on. When you make changes to your code, the HEAD is updated to point to the new commit that includes those changes

### Creating a Repo
A GitHub repo, or repository, is a location where code and other files associated with a project are stored and managed using Git version control.
#### Init
In order to designate a directory on your local machine as a git repository you run the command:
```c
git init
```
This initializes the Git repository in by creating a .git directory with subdirectories and files that are used by git to manage the directory as a Git repository.

Once a Git repository is initialized with git init, you can use other Git commands to manage your code. Note this only initializes a repository locally, you still need to publish the repository to github in order to view and share your code to others.
#### Clone

In order to access a remote repository you will use git clone. This is used to create a copy of a remote Git repository on your local machine. The cloned repository is an exact copy of the remote repository, including all branches, tags, and commit history. You can usually find the clone url by visiting the Github page of the repo you are trying to clone.

```c
git clone https://github.com/username/repository.git
```

### Adding content to the Repo
Once we have created a local or remote repository and have it downloaded on our machine we can now start to interact with the source control features to manage our code.
#### Add
git add is a Git command used to add changes made to the files in a local repository to the staging area. The staging area is a temporary storage area where Git keeps track of changes before committing them to the repository.

Here are some common uses of the git add command:

```c
git add .
```
Adds all changes in the current directory and its subdirectories to the staging area.

```c
git add <filename>
```
Adds changes to a specific file to the staging area.

```c
git add -p
```
Allows you to interactively add changes to the staging area.

#### Commit
A command that saves changes made to the files in a local Git repository. It creates a permanent record of the changes made since the last commit, including the files that were changed, the contents of those files, and a commit message that describes the changes made.

A Git commit is typically used after making changes to the files in a local repository and adding those changes to the staging area using the git add command. Once the changes are staged, you can use the git commit command to permanently save them to the repository. 
```c
git commit -m "commit message"
```
The -m option is used to specify a commit message, which should briefly describe the changes made in the commit. Some projects will have particular requirements around the formatting of the message and can even use tools that block commits unless the message follows the desired format.

After executing the commit command a unique identifier called a hash will be created. This can be used to refer to the commit in the future.
### Viewing The Repo
There are several commands that you can run to give you more information about the state of your repository. 
#### Status
See which changes are staged and which ones are not.
```c
git status
```

#### show
displays information about a specific Git object, such as a commit, tag, or tree. It allows you to see the details of a specific object, including the changes made, the author and committer information, and the commit message.
```c
git show <object>
```
#### diff
Shows the differences between two versions of a file or between two branches. It allows you to see the changes made to a file, including which lines were added, deleted, or modified.
```c
git diff <commit> <commit>
```
#### log
Display a chronological list of commits in a repository. It shows the commit history of a branch, along with the author and committer information, the commit message, and the hash of each commit.
```c
git log
```

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