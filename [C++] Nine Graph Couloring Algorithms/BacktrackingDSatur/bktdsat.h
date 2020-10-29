#ifndef BKTDSATDEF
#define BKTDSATDEF

#include "colorrtns.h"

#define ENDLIST 65535

extern void bktdsat(
	popmembertype *m, int branch,
	colortype targetclr, int min,int max);

/* use abacktrack version of dsatur, with
limited branching and forbidden branch ranges */

/* interrupt  control */
extern void cpulimbk();
extern void intfcbk();


#endif