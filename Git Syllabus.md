# Git

## What is Git

Git is a free and open-source distributed version control system (VCS) used for software development and other version control tasks.

With Git, you can track changes made to your code over time, and collaborate with other developers as you wish. 

When Git was created, what set it apart from other version control systems was how easy it was to create entirely new versions of files and file trees.  This made experimentation and iteration simple and rapid, and allowed isolation of changes from the main codebase until the developer was sure it was ready to be integrated back.  

Git also enabled developers to work on their own version of the codebase locally, avoiding the risk of overwriting each other's changes.  
This is referred to as a distributed model, which means that every developer has their own copy of the code repository on their local machine. This allows developers to work offline and independently, while still being able to push their changes to one or more shared remote repository(ies).

When the team is ready to consolidate code to prepare for release, Git provides tools for merging versions and resolving conflicts that may arise when multiple developers make changes to the same file.

### A Database
Git creates its own version of a file structure in a collection called a repository.  Via the repository, Git stores the entire history of your project, including every change made to every file, in a series of snapshots called commits. 

A commit represents the current state of the file structure by referencing it's parent, and a *tree* , along with other metadata like the author of the commit and the commit message.  Since every commit references at least one parent, a chain of changes is established, and this is how git can move between different versions of the repository and maintain continuity.  

This is why Git is fundamentally a database.  By maintaining a record of the relationships between files, and changes to those files, Git can recreate the repository from any state that was committed to it over time.

### A Version Control System
A version control system allows you to save *multiple* versions of a file, or a file tree. Git is widely used in software development and other version control tasks. By allowing you to track changes, create branches, merge changes, and revert to earlier versions, Git helps you keep your code organized and under control.  This is a powerful way to manage your work, whether you are working alone or with a team. 

### A Collaboration Framework
Git makes it easy to collaborate with other developers by providing tools for sharing code and resolving conflicts that may arise when multiple developers are working with the same set of files.  Once you've made changes in a local repository, you and your team can choose to merge those changes back into the main codebase when you're ready.

## Git Setup

### Install

On a Mac just type in git into the terminal and it has a built in process to automatically download and setup git for you.

On Windows you can download the package directly from this url: https://git-scm.com/download/win

### Configure
Git uses multiple config files to define the environmental variables it requires to function.  Config files are defined for 
- System
- User
- Repository

When git is installed, a .gitconfig file is created in the Git directory specified at install.  By default on windows, this will be 

```c
C:\Program Files\Git\etc\.gitconfig
```

When a **user** config file is created, the default location on Windows wiil be
```c
C:/users/< user>/.gitconfig
```

Config files are also included in a repository to define separate configurations (such as remotes) for that particular repository.  When a new repository is created, git automatically creates a config for it.

```ad-tip
title: Config Hierarchy
Git config files are used in a hierarchy.  
- Each key from each config file (System, User, Repository) will be loaded into git
- The closest config file will win if the same key is defined in different config files 
```


To work with git, you will need to define at a minimum a user name and email. If either of these keys are not found, a commit will fail with an error message describing the missing key.

```c
//SET config values
git config --global user.name "< user name>"
git config --global user.email "< user email>"
git config --edit --global //Opens .gitconfig in defined editor

// REMOVE a config value:
git config --unset [section].variable // git config --unset alias.nf

//SHOW config values
git config --list //show all config keys
git config --list --show-origin //show all keys, AND origin (file, etc.) of key value
git config --global --get user.name //Retrieves just the value of user.name
```

#### Alias
The [alias] group in a config file is used to define shorthand or meaningful names for often-used commands.  Aliases are executed as if you entered the aliased command, thus any valid parameter for the underlying command can be used with the alias.  Aliases can be defined in any of the config files used by git, so users can create more general or repository-specific aliases as required or preferred.

```c
git config alias.<alias name> <command to alias>

// Can define aliases PER REPO, PER USER, or SYSTEM

git config --global|system|local alias... //User|system|repository config level

// Can alias command-line options
git config  --global alias.cma "commit --all -m"

// Can alias parameters
git config --global alias.qm '!git checkout $1; git merge @{-1}' // ! - exec shell command - must be a command KNOWN to git, e.g. "echo" cannot be used

// will merge the most recent commit into the named branch
git qm master
```


## Git Tooling

### Git/OS
#### CLI
##### posh-git

#### CMD
##### Far Manager
  

### Coding
#### VS Code
https://code.visualstudio.com/

#### GitLens
https://marketplace.visualstudio.com/items?itemName=eamodio.gitlens

#### Webstorm
https://www.jetbrains.com/webstorm/promo/?source=google&medium=cpc&campaign=9641686293&term=webstorm&content=523713720609&gad=1&gclid=CjwKCAjwl6OiBhA2EiwAuUwWZfOsd5swCJvia-9liNvXoi7U4mmGlu_qImf84Fxl23f-Qeaj1Q6lbxoCEP4QAvD_BwE
  

### Gitting
#### Tower Git
https://www.git-tower.com/windows

#### GitHub Desktop (free)
https://desktop.github.com/

#### Git Kraken (free)
- Same company that publishes GitLens for VSCode
https://www.gitkraken.com/

#### SourceTree (free)
https://www.sourcetreeapp.com/

#### Tortoise Git for Windows (free)
- Shell integration
https://tortoisegit.org/

  

### Comparing
#### Beyond Compare
https://www.scootersoftware.com/

#### VS Code
https://code.visualstudio.com/

#### KDiff3 (free)
https://kdiff3.sourceforge.net/

#### P4Merge (free)
https://www.perforce.com/products/helix-core-apps/merge-diff-tool-p4merge

#### WinMerge (free)
https://winmerge.org/?lang=en
  

## Git Internals
### The Working Directory
The local set of files that can be managed by .git. Any files or folders in the same directory as the .git folder, and any child directories, are considered the working directory

### The Staging Area (Index)
The collection of files that will be added to or modified with the next commit.  Exists to to provide decoupling between working files and commits (can commit some of current changes separately from others, for better traceability/workflow)

### The Repository
Git's representation of the working directory.  Represents the total collection of files and folders that are **tracked** by git

### The Database
Comprises all of the folders and files in the .git directory
#### Database Objects
```sh
git count-objects -H -v //Shows top-level information about the database -H human readable, -v verbose
git cat-file --batch-all-objects --batch-check //shows ALL objects in the database
```

##### Blobs
Files in the git database.  Use git cat-file to see contents.

```ad-note
title: Files and Blobs
A "file" exists in two places in a git repository:

- Working Directory
- Repo blob

Even if a file is deleted from the Working Directory, it can be restored from the repository!
```

##### Trees
Analagous to directories.  Shows directory/file structure at time of commit

Different trees can reference the same objects:

![Image](images/Pasted%20image%2020230414152321.png) 

![Image](images/Pasted%20image%2020230414152240.png) 

##### Commits
- A **unique** collection of tree and blobs.  
	- **COMMIT** contains only one tree
	- **TREE** can contain >1 tree.  This is how child folders are represented.
	- Any tree represents a single level of folder. Subfolders in a folder are represented as another tree in a tree.
- Slice-in-time capture of the state of the repository.  Contains information on parent(s) of commit, the tree associated with the commit, and **metadata**
	- author
	- commiter
	- message

```ad-question
- When would a commit have more than one parent?
- Why would there be an author AND a committer?
```


```c
$git cat-file -p < hash >
$cat < filename >
```
  

  ```ad-important
FILES != OBJECTS

- If a FILE is deleted, the OBJECT representing the file still exists. The TREE representing the working directory will not have references to those files though, so eventually garbage collection will delete the 'Unreferenced' objects.


- Branching from a commit that had a tree referencing the deleted files will restore the FILES to the working directory from the OBJECTS in the database
```
  
### The Stash
The stash allows you to temporarily save changes in your working directory that are not ready to be committed. This is useful if you need to switch to a different branch or work on a different task, but want to save the changes you've made so far without committing them to the repository. You can save multiple changes to your stash that can be applied to any branch you are currently working in.

```c
git stash save --include-untracked  //takes all uncommitted data from working area and index and copies to stash, then copies current commit back to index and working area
git stash list  //shows all stashed collections
git stash apply <stash element name>  //move data to working area and index
git stash clear
```

  

## Using Git

### What is a commit?
A commit is a snapshot of the current state of a Git repository. It includes a set of changes to the repository's files that you've made since the last commit, along with a commit message describing the changes. Commits allow you to keep track of changes to your code over time

### What is a branch?

```ad-tip
- A BRANCH is simply a NAMED POINTER to a commit.  As commits are made to the branch, the pointer will point to the most recent commit on the branch (refs/heads/<branch name>)
- When a branch is checked out, the HEAD file is updated to reference the checked out branch
```

A branch is a separate line of development in a Git repository. It's essentially a copy of the codebase at a certain point in time, and you can make changes to it without affecting the main codebase. This allows you to experiment with new features or make changes without worrying about breaking the existing code. Braches are made up of commits, and you can see the entire history of a single branch by checking its commit history

```ad-question
How is a BRANCH the opposite of a MERGE? (You may need to scroll down a bit to answer this right now ;) )
```


### What is the HEAD?
HEAD is an indirect reference to the latest commit in the active branch, so identifies the current commit and defines the parent of the next commit. Each new commit results in HEAD pointing to the newest commit.

```ad-question
title: What is a DETACHED HEAD?
A detached head is the state when HEAD references a specific commit hash, rather than a branch.  If commits are made in this state, they will be lost (eventually) if a branch is checked out, because there will be no durable reference to commits made in the detached state. This can be useful if you wish to do experimentation or throwaway commits without having to be concerned about someone else seeing them, or causing any sort of merge problems.



[Detached Head](https://git-scm.com/docs/git-checkout)
```  

```c
git checkout --detach [<branch name>]
git checkout [--detach] <commit hash>   //note detach argument is not strictly required when checking out a commit directly
```

```ad-note
Git gives a good explanation of the detached status and your options 
![[Pasted image 20230427115028.png]]
```

### Creating a Repo
A GitHub repo, or repository, is a location where code and other files associated with a project are stored and managed using Git version control.

#### Init
In order to designate a directory on your local machine as a git repository you run the command:

```c
git init //create new repository
	-b <branch name> //override the name of the default branch (e.g. master/main)
```

This initializes the Git repository in by creating a .git directory with subdirectories and files that are used by git to manage the directory as a Git repository.

Once a Git repository is initialized with git init, you can use other Git commands to manage your code. Note this only initializes a repository locally, you still need to publish the repository to github in order to view and share your code to others.

```ad-tip
title: Clone
In order to access a remote repository you will use git clone. This is used to create a copy of a remote Git repository on your local machine. The cloned repository is an exact copy of the remote repository, including all branches, tags, and commit history. You can usually find the clone url by visiting the Github page of the repo you are trying to clone.


```c
git clone https://github.com/username/repository.git
```

  

### Adding content to the Repo
Once we have created a local or remote repository and have it downloaded on our machine we can now start to interact with the source control features to manage our code.

#### Add
```c
git add <pathspec> //Adds any files defined by pathspec to the index
	-p             //select SPECIFIC changes from the diff to stage
	-A | --all     //Adds ALL changed tracked and untracked files
	.              //Adds files in current directory and below, recursively (need to be aware of where you are in directory - will NOT add files ABOVE current location)
```
Adds files to staging area, a necessary precursor to committing 


### Removing Files
rm removes files from the index, or the index + working tree

```ad-hint
There is no git command to only remove files from the working tree.  Delete the file outside of git.
```

```c
git rm <filename> // 
	--cached      //removes file from index 
	-f            //removes file from index + working area - UNSTAGES the file(s)
```

### Moving Files
```c
git mv <old file name> <new file name>
```

### Staging Commits
Index allows you to specify EXACTLY what should be included in a commit

#### diff
```c
git diff          //show diff of files only in the working directory to the head, in CLI
	--staged      //show diff of files in the INDEX to the head

git diff <object|hash> <object|hash> //show diff of two specified objects
git difftool -y <object|hash> <object|hash> //invokes defined difftool to show files side-by-side

```

```ad-important
Once a file is added to the index, any changes made after are done to a CACHED copy of the file.  You must use git add AGAIN to get the new changes staged
```

```c
git reset HEAD // unstages any changes in the index 
```

#### Commit
```c
git commit <pathspec>
	-a        //Includes ALL staged files in the commit
	-m        //message to add to the commit.  Use MULTIPLE -m flags to add multiple messages (e.g. title/subject)
```

"Moves" files from staging area to repository. (Technically, commit creates new blob objects in the git database for every file in the staging area, and creates a new tree hash that incorporates new or changed files)

The -m option is used to specify a commit message, which should briefly describe the changes made in the commit. Some projects will have particular requirements around the formatting of the message and can even use tools that block commits unless the message follows the desired format.

```ad-hint
http://whatthecommit.com
```

After executing the commit command a unique identifier called a hash will be created. This can be used to refer to the commit in the future.

```ad-important
title: Every Object is a NEW Object
Git objects are IMMUTABLE. This means if ANY CHANGES at all need to be made to an object, a COPY of the object will be made, the changes will be added, and any references to the old version will be removed
```

### Viewing The Repo

#### Status
See which changes are staged and which ones are not.

```c
git status
```
  
#### Show
```c
git show //by default shows difference between specified commit and it's PARENT
git cat-file -p <object hash> //similar to show, but includes more database metadata in the output
```

```ad-hint
show command accepts same formatting options as log  //use alias
```

Git blobs contain ENTIRE contents of files - diff calculates differences on the fly

DELTA CHAIN - all of the CHANGES in a commit (unchanged files are not copied when commit is generated)

Can compare specific files within commits

#### log
Display a chronological list of commits in a repository. It shows the commit history of a branch, along with the author and committer information, the commit message, date and hash of each commit

```ad-tip
git log is one of the most useful, but complex commands in git

https://git-scm.com/docs/git-log
```

```c
git log
	--format=oneline //hash + message 
	--abbrev-commit //short (7 char) hash
	--graph //shows commits in a branching struture
	--decorate[=short|full|auto|no] //prints out ref name prefixes (e.g. refs/heads/master) 
	--pretty=oneline //formats output (too many options to list)
	--all //shows commits from ALL branches
	--name-status 
	--patch  //include change details of every commit shown

log -1 HEAD
```

```ad-hint
http://git-scm.com/docs/pretty-formats
```

  ```ad-warning
  Log can be used for a RANGE of commits as well

git log <starting (oldest) condition>(exclusive)..<end (newest) condition>(inclusive) //show commits from start to end, e.g. git log HEAD~5..HEAD^ --oneline <-- shows commmits from 5 steps before head, to the parent of HEAD  
```

### Moving within the Repo
You will need to know how to navigate between branches in order to succesfully contribute your code

#### branch
```c
git branch < branch name>  //creates new branch with name given
	-d <branch name> //delete a merged branch
	-D <branch name> //delete branch, even if not merged to main
	-a //show ALL local and remote branches
	-m <old name> <new name>: Renames the specified branch.
	-r //show REMOTE branches
	-v //verbose: show hash and subject message
```

Used to manage the branches in your local repository

#### checkout/switch
```c
git checkout -b < branch name> //creates new branch and sets it to active
git switch -c <branch name>  //create and switch to the named branch
git checkout < branch name> //makes specified branch the active branch
	-f <branch name> //forces checkout of named branch, even if uncommitted changes exist 
git switch < branch name> //will switch to named branch if it exists
	-f <branch name> //forces checkout of named branch, even if uncommitted changes exist
```

You can use the checkout command if you want to actually switch over to a branch commit or file in your local repository.

#### tag
```c
git tag <tag-name> //creates a tag for the commit at HEAD
git tag <tag-name> <commit-hash> //creates tag name for specific commit
 -d <tag name> //deletes the tag
 -a <tag name> //create annotated tag
```

A tag is a label or bookmark that is associated with a specific commit in a repository. Tags are typically used to mark significant milestones, releases, or versions of a project, and they provide a way to easily reference a specific commit in the future.

"Annotated" tags have associated metadata (creation date, tagger name/email, message) and are intended for production release.

### Modifying the Repo

#### Merge
Merge is a command that is used to combine changes from one branch into another. It is one of the core features of Git that enables collaboration among developers working on the same project.

As an example, lets say we have a feature branch that we want to merge back into our main branch.

1. Switch to feature branch

```c
git switch feature-branch
```

2. Once your code is dev complete begin merge process back into main. Start with switching to main branch

```c
git checkout main
```

3. Merge the changes from your feature branch into the main branch

```c
git merge feature-branch
```
  
This command will take all of the changes in your feature-branch into the main branch and create a merge commit

```ad-hint
Technically, a merge creates a NEW commit with TWO parent commits - the last commit from each of the two branches involved in the merge
```

#### Rebase

The rebase command can be used to apply changes from one branch onto another. Unlike git merge, which creates a new merge commit, git rebase applies changes from one branch directly on top of another branch's history, resulting in a linear project history. This changes the history of the branch you are rebasing into, which can make the history difficult to trace. 

```ad-hint
Where merge creates a commit with two parents, rebase will maintain a linear commit chain in which each commit has a single parent
```

```ad-warning
NEVER rebase a branch that has been pushed to a remote repository.  BAD THINGS WILL HAPPEN
```

### Fixing the Repo

Sometimes we run commands and make changes to our repo that we do not intend to make. Here are a few options to undo the changes that have been made.
  

#### Conflicts
Sometimes when you are merging code you will have conflicts between two of the same files. This occurrs when two contributors make changes to the same part of the same file, git will give you conflict markers and will allow you to decide which of the changes to include.

#### Amend commit
This will make changes to the most recent commit in your repository. This can be useful if you notice a mistake or typo in your commit message or if you need to add or remove files from the commit. You are essentially replacing the old commit with your latest updates. This can cause issues if you have multiple contributors working off of a commit that you plan to ammend.

To ammend a commit
```c
git commit --amend
```

#### Revert
When you use revert, it creates a new commit that contains the opposite changes to the original commit. For example, if the original commit added a line of code, the revert commit would remove that line of code. This is useful when you need to undo a previous commit without completely removing it from the repository history.

To revert a commit
```c
git revert <commit-hash>
```

#### Reset
Reset can have different results in different contexts.  Technically, the command RESETS the HEAD to a specified state.  Note this does NOT mean MOVE the head, necessarily (though it can)

Enables you to delete (dereference) commits you no longer want in the branch (recall DETACHED HEAD -- a different way to accomplish the same thing)

```c
git reset HEAD              //removes changes from the index -- the OPPOSITE of git add
git reset <options> <hash>  //set the current branch HEAD (refs/heads/<branch-name>) to the specified hash 
	--hard                  //copies data from new current commit to working area and index
	--mixed                 //DEFAULT OPTION copies data from new current commit to index but leaves working area alone
	--soft                  //moves commit, but does not affect index or working area
```

#### Reflog
The reflog tracks EVERY time a reference moves in the repository (represented by an update to files in the refs/ folder)

reflog is a useful command for managing your repository and tracking the history of changes made to your code. It provides a way to recover lost commits and branches, and can help you undo changes that may have been accidentally deleted.

Entries in the reflog also have hash identifiers - not every object shown in the reflog is going to be a commit object:

![Image](images/Pasted%20image%2020230427120912.png) 

```ad-note
title:Reflog Syntax

Entries in the reflog are labeled with their proximity to the current state:

Current entry is labeled HEAD@{0}
Previous entry is labeled HEAD@{1}, etc.

&nbsp;

These labels can be used in other commands like show and log:
 
git show HEAD@{4}

git log HEAD@{10}..HEAD@{2}
```
  
#### Interactive Rebase
You can also fix errors by creating a new commit with the corrected code, and rebasing to squash previous commits into the new commit, essentially overwriting the error commit.

Interactive rebase can also be used to groom local branches, eliminating unimportant or meaningless commits so that the branch history reflects your work in a way more meaningful to others (no "WIP" commits, squash out "minor fix" commits, etc.)

```c
git rebase -i <beginning from (exclusive)>
```
![Image](images/Pasted%20image%2020230330115324.png) 
add squashes:
![Image](images/Pasted%20image%2020230330115538.png) 
Interactive rebase will go through all the included steps and pause where user input is required, in order to create the final rebased history


### Sharing the Repo
#### Push
Once you have committed your work locally and want to share the code with other devs, you can run the push command. This will take the branch you have  and send all commits to the specified remote repository (more than 1 remote repository can be tracked locally).

```c
git push 
```

#### Fetch
Retrieves changes from a remote branch, but does not merge them into your local branch.

#### Pull
Retrieves changes from a remote branch and merges them into your current branch

```ad-tip
title: Working with Others
It is a good idea to pull code frequently if you know others are making changes to a branch you are using or will be merging into.  This can help isolate merge conflicts to your local environment, and minimize the impact of these conflicts on your codebase.

&nbsp;

Update strategies will be discussed futher in the next session of the workshop

```

## Git Best Practices
While git is a powerful way to manage code across multiple developers it is still only a tool and needs a pattern behind it in order to be succesful in a real world environment.

### Finding a Workflow
The workflow that the team will operate on will depend on the team. Smaller teams can get away with smaller workflows and don't need to be bogged down by the extra steps in the heavier workflows like Gitflow. But as the team size grows the extra steps and processes will be required in order to ensure continuous high quality delivery of code.

You can always switch up workflows at any time. If you feel the way you are currently operating is not working there is no issue with switching over to a better fitting workflow.

#### Gitflow
This pattern involves creating two long-lived branches: a master branch for production-ready code, and a develop branch for ongoing development. Feature branches are created off the develop branch, and once they are complete, they are merged back into the develop branch. When the develop branch is stable, it is merged into the master branch for release.

#### Monolithic/Trunk
Trunk-based development (TBD) is a Git workflow pattern that involves working directly on the master branch, rather than using feature branches. In this workflow, developers make small, incremental changes to the codebase, committing them directly to the master branch as soon as they are complete.


### Being a good citizen
Part of being a good developer is working in a optimal and communicative way in git. Here are a few things to keep in mind to ensure you are working optimally within your team.

#### Commit size
Keep commits as concise as possible. Each commit should be able to stand on its own but should not be so large that the entire development of your feature gets pushed into a single commit.

Keep the commit history clean: Avoid making "noisy" commits that don't add value to the commit history, such as committing changes that were only made to fix typos or formatting. Instead, group related changes together into a single commit, and keep the commit history as clean and organized as possible.  (rebase -i is your friend here 😊 )
  

#### Branches
Use meaningful branch names: When creating branches, use meaningful names that describe what changes are being made on the branch. This makes it easier for other developers to understand what changes are being worked on, and helps to avoid confusion when merging branches.

#### Conventions
Follow the team's workflow: If your team has decided to follow a particular workflow, be sure to follow it consistently. This includes using the appropriate branch names, following the commit message conventions, and using the correct commands for merging and creating branches.

Review and test changes thoroughly: Before pushing changes to the remote repository, review and test them thoroughly to ensure they are working as expected. This helps to avoid introducing bugs or breaking the codebase for other developers.

#### Commit messages
Use clear and descriptive commit messages: When committing changes, use a clear and descriptive commit message that explains what changes were made and why they were made. This helps other developers understand the changes and makes it easier to roll back changes if necessary.


### Squash into Dev, Merge into Main
Another way to keep the commit history clean is to squash into dev and merge into main. When you squash a merge you are taking all of the commits in a single branch and merging them as one commit in the history. The result is a single atomic commit that gives you a clear when looking back at your main shared branches while allowing for the smaller more descriptive commits to exist with the feature branch.
  

# Further Learning

[Tower Git](http://www.git-tower.com/learn)

[Git SCM](https://www.git-scm.com/)

[Roger Dudler](http://rogerdudler.github.io/git-guide/)
