# Create git database

![Image](../images/Pasted%20image%2020230509093612.png)
- Repo populated with default files

# Add file
![Image](../images/Pasted%20image%2020230509093701.png)

- Index file created if it doesn't exist already
- Object created for added file in .git/objects/

# Remove same file

![Image](../images/Pasted%20image%2020230509093356.png)
- Reference to file removed from index (note no object changes)

# Re-Add same file
![Image](../images/Pasted%20image%2020230509094117.png)
- Reference to file added back to index (note no object changes)

# Commit file to repo
![Image](../images/Pasted%20image%2020230509094244.png)
- New log file: .git/logs/refs/heads/main
- New objects
	- Tree aab69...
	- Commit 50a4e...
- New ref file: .git/refs/heads/main
- New commit message file COMMIT_EDITMSG

# Edit Same File
![Image](../images/Pasted%20image%2020230509102818.png)

# Add Edited File
![Image](../images/Pasted%20image%2020230509103139.png)
- Index updated:
	- ![[Pasted image 20230509103208.png]]
- New object created (objects are immutable)

# Commit Edited File
![Image](../images/Pasted%20image%2020230509103723.png)
- Main branch log file updated: .git/logs/refs/heads/main
- Objects added:
	- Commit 1d/58ad
	- Blob b1/4243
- COMMIT_EDITMSG updated

# Force Garbage Collection
![Image](../images/Pasted%20image%2020230509111147.png)
- .git/refs/heads/main deleted
- .git/objects moved to ~/pack
- .git/objects/.. deleted
- .git/info/refs created
- packed-refs created

## PackFile
If delta is small relative to overall file size, git will just pack the delta instead of 2 (or more) separate objects

When cloning, or pushing to remote, git uses pack files to manage objects in the database

```
C:\temp\PluralsightSpaJumpStartFinal(master -> origin)
λ tree /F
Folder PATH listing for volume OS
Volume serial number is C0000100 7ACF:069C
C:.
│   .gitattributes
│   .gitignore
│   flush.cmd
│   README.md
│   SPAJumpStart.sln
│
├───.git
│   │   config
│   │   description
│   │   HEAD
│   │   index
│   │   packed-refs
│   │
│   ├───hooks
│   │       applypatch-msg.sample
│   │       commit-msg.sample
│   │       fsmonitor-watchman.sample
│   │       post-update.sample
│   │       pre-applypatch.sample
│   │       pre-commit.sample
│   │       pre-merge-commit.sample
│   │       pre-push.sample
│   │       pre-rebase.sample
│   │       pre-receive.sample
│   │       prepare-commit-msg.sample
│   │       push-to-checkout.sample
│   │       update.sample
│   │
│   ├───info
│   │       exclude
│   │
│   ├───logs
│   │   │   HEAD
│   │   │
│   │   └───refs
│   │       ├───heads
│   │       │       master
│   │       │
│   │       └───remotes
│   │           └───origin
│   │                   HEAD
│   │
│   ├───objects
│   │   ├───info
│   │   └───pack
│   │           pack-2436dbec9c271df07f75041716ed319f12c5f3a8.idx
│   │           pack-2436dbec9c271df07f75041716ed319f12c5f3a8.pack
```

```ad-note
title: Pack Files

.git/objects/pack/{}.pack

.git/objects/pack/{}.idx

.idx file has POINTERS to file content of different files packed into .pack file
```

![Image](../images/Pasted%20image%2020230509120459.png)

![Image](../images/Pasted%20image%2020230509120515.png)

![Image](../images/Pasted%20image%2020230509120535.png)

```c
git verify-pack -v .git/objects/pack/pack-49f4f40715c6910fbfbf7e9b0cf0ec0a9275a73f.idx
```

![Image](../images/Pasted%20image%2020230509121152.png)


# Delete File
![Image](../images/Pasted%20image%2020230509130313.png)
![Image](../images/Pasted%20image%2020230509130335.png)