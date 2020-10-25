# This makefile builds all the graph coloring executables

GLOBALFLAGS := "-Wno-sign-compare -Wno-unused-but-set-variable"
 
subdirs := AntCol BacktrackingDSatur DSatur HillClimber HybridEA IteratedGreedy PartialColAndTabuCol RLF SimpleGreedy

.PHONY: all ${subdirs} clean

all: ${subdirs}

${subdirs}:
	${MAKE} -C $@ GFLAGS=${GLOBALFLAGS}

clean:
	for dir in ${subdirs}; do \
          $(MAKE) -C $$dir clean; \
        done
